import Vue from 'vue';
import App from './App.vue';
//import VueFormulate from '@braid/vue-formulate'
import axios from 'axios'

//Vue.config.productionTip = true;

Vue.prototype.$axios = axios.create({
    baseURL: `https://localhost:7004`,
    withCredentials: false
});

/*
Vue.use(VueFormulate, {
    uploader: axiosClient,
    uploadUrl: ''
})
*/

new Vue({
    render: h => h(App)
}).$mount('#app');