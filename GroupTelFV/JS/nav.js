const btnNavEl = document.querySelector('.btn-nav-mobile');
const headerEl = document.querySelector('.header');
const prodBtnEl = document.querySelector('.prod-btn');

btnNavEl.addEventListener('click', function () {
    headerEl.classList.toggle('nav-open');
});

prodBtnEl.addEventListener('hover', function () {
    prodBtnEl.classList.toggle('float');
});
