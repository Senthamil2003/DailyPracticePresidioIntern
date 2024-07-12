<template>
    <div class="home-wrapper">
        <div class="actions-container">
            <router-view></router-view>
        </div>

        <div class="card-info">
            <div v-if="showBack" class="back-btn-container">
                <button @click="goBack" class="back-button">
                    <v-icon icon="mdi mdi-arrow-left"></v-icon>
                </button>
            </div>
            <div class="card-details">
                <p>Card No: {{ cardNo  }}</p>
                <v-btn color="error" @click="cancel">Cancel</v-btn>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "Home",
    data() {
        return {
            cardNo:""
        }
    },  
    computed: {
        showBack() {
            return this.$route.name !== "Options" 
        }
    },
    beforeMount() {
        this.cardNo = sessionStorage.getItem("card")
        if (!this.cardNo) {
            this.cancel()
        }
    },
    methods: {
        cancel() {
            sessionStorage.removeItem("token")
            sessionStorage.removeItem("card")
            this.$router.replace({name:"Auth"})
        },
        goBack() {
            this.$router.go(-1)
        }
    }
};
</script>

<style scoped>
.home-wrapper {
    height: 100vh;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    align-content: center;
    overflow: hidden;
    gap: 1em;
}

.actions-container {
    height: 100%;
    overflow: hidden;
    display: flex;
    justify-content: center;
    align-items: center;
    flex: 1;
}

.card-info {
    height: 100vh;
    width: min(40%, 20em);
    background-color: #D9D9D9;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.back-btn-container {
    width: 100%;
    padding: 1em
}


.card-details {
    display: flex;
    justify-content: center;
    flex-direction: column;
    flex: 1;
    max-width: 90%
}

.card-info p {
    margin: 0;
    margin-bottom: 1em;
}

</style>
