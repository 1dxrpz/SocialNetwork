<template>
    <div id="app">
        <Home msg="Hello world!" />
    </div>
</template>

<script>
    import Home from './components/Home.vue';
    import axios from 'axios';

    axios.defaults.baseURL = 'https//localhost:7004';
    export default {
        name: 'app',
        components: {
            Home
        }
    };
</script>

<style>
</style>

