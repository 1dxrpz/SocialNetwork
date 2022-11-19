<template>
    <div id="app">
        <Home msg="Hello world!" />
        <img src="https://localhost:7004/api/Files/getimage?id=922c08be-0589-4174-891b-cd249d6c1ad2" alt="." />
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

