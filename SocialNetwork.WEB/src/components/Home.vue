<template>
    <div class="home">
        <UploadImage></UploadImage>
    </div>
</template>

<script>
    import UploadImage from './UploadImage.vue';
    export default {
        name: 'Home',
        props: {},
        components: {
            UploadImage
        }
    };
</script>

<style scoped>
</style>

