/* ===== CUSTOM CURSOR ===== */
const cursorDot = document.createElement('div');
const cursorRing = document.createElement('div');
cursorDot.className = 'cursor-dot';
cursorRing.className = 'cursor-ring';
document.body.appendChild(cursorDot);
document.body.appendChild(cursorRing);

let mouseX = 0, mouseY = 0, ringX = 0, ringY = 0;

document.addEventListener('mousemove', e => {
    mouseX = e.clientX; mouseY = e.clientY;
    cursorDot.style.left = mouseX + 'px';
    cursorDot.style.top = mouseY + 'px';
});

function animateRing() {
    ringX += (mouseX - ringX) * 0.12;
    ringY += (mouseY - ringY) * 0.12;
    cursorRing.style.left = ringX + 'px';
    cursorRing.style.top = ringY + 'px';
    requestAnimationFrame(animateRing);
}
animateRing();

document.querySelectorAll('a, button').forEach(el => {
    el.addEventListener('mouseenter', () => {
        cursorRing.style.width = '56px';
        cursorRing.style.height = '56px';
        cursorRing.style.borderColor = 'rgba(37,99,235,0.8)';
    });
    el.addEventListener('mouseleave', () => {
        cursorRing.style.width = '36px';
        cursorRing.style.height = '36px';
        cursorRing.style.borderColor = 'rgba(37,99,235,0.5)';
    });
});

/* ===== NAV SCROLL ===== */
const nav = document.getElementById('siteNav');
window.addEventListener('scroll', () => {
    nav?.classList.toggle('scrolled', window.scrollY > 40);
});

/* ===== MOBILE MENU ===== */
const menuToggle = document.getElementById('menuToggle');
const navLinks = document.querySelector('.nav-links');
menuToggle?.addEventListener('click', () => {
    navLinks?.classList.toggle('open');
});
navLinks?.querySelectorAll('.nav-link').forEach(link => {
    link.addEventListener('click', () => navLinks.classList.remove('open'));
});

/* ===== SCROLL REVEAL ===== */
const revealObserver = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            const el = entry.target;
            const delay = el.dataset.delay || 0;
            setTimeout(() => el.classList.add('revealed'), delay * 1000);
            revealObserver.unobserve(el);
        }
    });
}, { threshold: 0.12, rootMargin: '0px 0px -60px 0px' });

document.querySelectorAll('.reveal-up, .reveal-left, .reveal-right').forEach((el, i) => {
    // Stagger siblings
    const siblings = el.parentElement?.querySelectorAll('.reveal-up, .reveal-left, .reveal-right');
    if (siblings) {
        siblings.forEach((sib, idx) => {
            sib.dataset.delay = (idx * 0.1).toFixed(2);
        });
    }
    revealObserver.observe(el);
});

/* ===== SKILL BAR ANIMATION ===== */
const skillObserver = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.querySelectorAll('.skill-fill').forEach((fill, i) => {
                setTimeout(() => fill.classList.add('animated'), i * 120);
            });
            skillObserver.unobserve(entry.target);
        }
    });
}, { threshold: 0.3 });

document.querySelectorAll('.skills-grid').forEach(el => skillObserver.observe(el));

/* ===== LANGUAGE TOGGLE ===== */
let currentLang = localStorage.getItem('portfolioLang') || 'en';
applyLang(currentLang);

function toggleLang() {
    currentLang = currentLang === 'en' ? 'tr' : 'en';
    localStorage.setItem('portfolioLang', currentLang);
    applyLang(currentLang);
}

function applyLang(lang) {
    document.documentElement.setAttribute('data-lang', lang);
    document.querySelectorAll('[data-tr][data-en]').forEach(el => {
        const text = el.dataset[lang];
        if (text) el.textContent = text;
    });
    // Update toggle display
    const toggle = document.getElementById('langToggle');
    if (toggle) {
        const active = toggle.querySelector('.lang-active');
        const inactive = toggle.querySelector('.lang-inactive');
        if (active && inactive) {
            active.textContent = lang.toUpperCase();
            inactive.textContent = lang === 'en' ? 'TR' : 'EN';
        }
    }
    // Update html lang attr
    document.documentElement.lang = lang;
}

/* ===== ACTIVE NAV ON SCROLL ===== */
const sections = document.querySelectorAll('section[id]');
const sectionObserver = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            const id = entry.target.id;
            document.querySelectorAll('.nav-link').forEach(link => {
                link.style.color = link.getAttribute('href') === `#${id}`
                    ? 'white' : '';
            });
        }
    });
}, { threshold: 0.4 });
sections.forEach(s => sectionObserver.observe(s));

/* ===== SMOOTH NUMBER COUNTER (for future use) ===== */
function countUp(el, target, duration = 1500) {
    let start = 0;
    const step = (timestamp) => {
        if (!start) start = timestamp;
        const progress = Math.min((timestamp - start) / duration, 1);
        el.textContent = Math.floor(progress * target);
        if (progress < 1) requestAnimationFrame(step);
    };
    requestAnimationFrame(step);
}

/* ===== PARALLAX HERO ===== */
window.addEventListener('scroll', () => {
    const scrollY = window.scrollY;
    const orb1 = document.querySelector('.orb-1');
    const orb2 = document.querySelector('.orb-2');
    if (orb1) orb1.style.transform = `translateY(${scrollY * 0.15}px)`;
    if (orb2) orb2.style.transform = `translateY(${-scrollY * 0.1}px)`;
    const heroContent = document.querySelector('.hero-content');
    if (heroContent) heroContent.style.transform = `translateY(${scrollY * 0.2}px)`;
});
