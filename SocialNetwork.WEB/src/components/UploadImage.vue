<template>
    <div class="uploadAvatar">
        <input type="file" name="image" @change="onFileSelected" />
        <button type="submit" @click="onUpload">Upload</button>
    </div>
</template>
<script>
    export default {
        name: 'UploadImage',
        methods: {
            onFileSelected(event) {
                this.selectedFile = event.target.files[0];
            },
            onUpload() {
                const formData = new FormData();
                formData.append('image', this.selectedFile)
                this.$axios
                    .post('api/User/uploadimage', formData, {
                        onUploadProgress: event => {
                            console.log(Math.round(event.loaded / event.total) * 100);
                        }
                    })
                    .then(res => {
                        console.log(res.data);
                    })
                    .catch(function (error) {
                        console.log(error.response.data);
                    });
            }
        },
        data: function () {
            return {
                selectedFile: null
            }
        }
    }
</script>

<style scoped>
</style>