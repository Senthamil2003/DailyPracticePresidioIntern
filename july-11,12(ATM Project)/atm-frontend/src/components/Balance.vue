<template>

    <div class="check-balance-wrapper">
        <div class="form-container">
            <h2>Balance</h2>
            <div class="message-container">
                <p v-if="loading" class="loader">Loading....</p>
                <p v-else>Your account balance: <span>{{balance}}</span></p>
            </div>
        </div>
    </div>
</template>


<script>
import axiosInstance from '@/axiosInterceptor';


export default {
    name: "Withdrawal",
    data() {
        return {
            loading: true,
            balance: ""
        }
    },
    async beforeMount() {
        try {
            const result = await axiosInstance.post("/api/Atm/CheckBalance")
            this.balance = result.data.balance
        } catch (error) {
            alert(error.response?.data.message || "Internal server error")
        } finally {
            this.loading = false
        }
    }
}

</script>


<style scoped>
.check-balance-wrapper {
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    padding: 2em;
}

.form-container {
    padding: 5em;
    background-color: #f0f0f0;
    align-self: center;
    width: 80%;
    display: flex;
    flex-direction: column;
}

::v-deep .form-container .v-btn {
    align-self: flex-end;
    width: 10em;
}

.message-container {
    padding: 1em 0;
    background-color: #f0f0f0;
}

.message-container span{
    font-weight: 600;
}

</style>