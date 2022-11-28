import Vue from 'vue';
import App from './App.vue';
import axios from 'axios'
import router from './router'

Vue.config.productionTip = false;

Vue.prototype.$axios = axios.create({
    baseURL: `https://localhost:7004`,
    withCredentials: false
});

new Vue({
    router,
    render: h => h(App)
}).$mount('#app');