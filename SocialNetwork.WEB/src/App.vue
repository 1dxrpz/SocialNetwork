<template>
    <div id="app">
        <!--
            <Home msg="Hello world!"></Home>
            <vue-markdown>i am a ~~test~~ **test**.</vue-markdown>
            <UploadImage></UploadImage>
        -->
        <component :is="layout">
            <router-view />
        </component>
    </div>
</template>

<script>
    //import axios from 'axios';
    //import UploadImage from './components/UploadImage.vue';
    //import VueMarkdown from 'vue-markdown';
    //axios.defaults.baseURL = 'https//localhost:7004';

    import MainLayout from '@/layouts/MainLayout.vue';
    import AccountLayout from '@/layouts/AccountLayout.vue';

    export default {
        name: 'app',
        computed: {
            layout() {
                return (this.$route.meta.layout || "Main") + '-layout';
            }
        },
        components: {
            //VueMarkdown,
            //UploadImage,
            MainLayout,
            AccountLayout
        },
    };
</script>

<style>
</style>
