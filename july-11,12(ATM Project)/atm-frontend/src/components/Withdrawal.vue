<template>
    <div class="withdrawal-wrapper">
        <div class="form-container">
            <h2>Withdrawal</h2>
            <v-form ref="form" @submit.prevent="processTransaction">
                <label for="amount">Amount:</label>
                <v-text-field v-model="amount" variant="outlined" density="compact" :rules="amountRules">
                </v-text-field>
                <v-btn type="submit" color="primary">Submit</v-btn>
            </v-form>
            <div v-if="loading" class="message-container">
                <p>Transaction is being processed...</p>
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
            amount: '',
            loading: false,
            amountRules: [
                v => !!v || 'Amount is required',
                v => !isNaN(parseFloat(v)) && isFinite(v) || 'Amount must be a number',
                v => (v <= 10000) || 'Cannot withdraw more than 10000 at one go'
            ]
        };
    },
    methods: {
        async processTransaction() {
            const { valid } = await this.$refs.form.validate()

            if (valid) {
                try {
                    this.loading = true;
                    const result = await axiosInstance.post(`/api/Atm/WithdrawMoney?amount=${this.amount}`)
                    console.log(result);
                    this.loading = false
                    this.$refs.form.reset()
                    this.$toast.open({
                        message: "Amount is Disbursed",
                        type: "success",
                        duration: 1500,
                        position: "top-left"
                    })
                } catch (error) {
                    alert(error.message)
                }
            }
        }
    }
};
</script>

<style scoped>
.withdrawal-wrapper {
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
    gap: 1em;
}

::v-deep .form-container .v-btn {
    margin-top: 2em;
    align-self: flex-end;
    width: 10em;
}

.message-container {
    margin-top: 2em;
    padding: 1em;
    background-color: #f0f0f0;
}
</style>
