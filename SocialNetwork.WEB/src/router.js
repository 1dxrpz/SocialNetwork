import Vue from 'vue';
import VueRouter from 'vue-router'
import Home from './views/Main/Home.vue'

Vue.use(VueRouter);

const routes = [
    {
        path: "/",
        name: "Home",
        meta: {
            layout: "Main"
        },
        component: Home
    },
    {
        path: "/account",
        name: "Account",
        meta: {
            layout: "Account"
        },
        component: () => import('./views/Account/Account.vue')
    }
];

export default new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});