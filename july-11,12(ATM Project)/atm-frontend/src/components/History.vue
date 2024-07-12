<template>

    <div class="history-wrapper">
        <div class="history-title">
            Transaction History
        </div>
        <div v-if="loading" class="loader">Loading....</div>
        <div v-else class="transactions">
            <div v-for="transaction in data" class="transaction">
                <div class="top-row">
                    <div class="transaction-amount" :class="transaction.transactionType"> {{ transaction.transactionType
                        === "Credit" ? "+":"-"}} {{ transaction.transactionAmount }}</div>
                    <div class="transaction-">{{ formatDate(transaction.transactionDateTime) }}</div>
                </div>
                <div class="desc">
                    {{ transaction.transactionDescription }}
                </div>
            </div>
        </div>
    </div>

</template>


<script>

import axiosInstance from "@/axiosInterceptor";

const dateMap = {
    0: "Jan",
    1: "Feb",
    2: "Mar",
    3: "Apr",
    4: "May",
    5: "Jun",
    6: "Jul",
    7: "Aug",
    8: "Sep",
    9: "Oct",
    10: "Nov",
    11: "Dec"
};


export default {
    name: "Withdrawal",
    data() {
        return {
            data: [],
            loading: true,
        }
    },
    async beforeMount() {
        try {
            const result = await axiosInstance("/api/Atm/GetTransaction")
            this.data = result.data
        } catch (error) {
            alert(error.response?.data.message)
        } finally {
            this.loading = false
        }
    },
    methods: {
        formatDate(str) {
            const temp = new Date(str);
            const month = dateMap[temp.getMonth()];
            const date = temp.getDate();
            const year = temp.getFullYear();
            let hours = temp.getHours();
            const minutes = (temp.getMinutes() < 10 ? '0' : '') + temp.getMinutes();
            const period = hours < 12 ? 'AM' : 'PM';

            if (hours > 12) {
                hours -= 12;
            } else if (hours === 0) {
                hours = 12;
            }

            const formattedDate = `${month} ${date}, ${year} - ${hours}:${minutes} ${period}`;
            return formattedDate;
        }
    }
}

</script>


<style scoped>
.history-wrapper {
    display: flex;
    flex-direction: column;
    height: 100%;
    width: 100%;
    padding: 1em;
    gap: 1em
}

.history-title {
    font-weight: 600;
    font-size: 1.2em
}

.transactions {
    display: flex;
    flex-direction: column;
    gap: .5em;
    flex: 1;
    overflow: auto;
}

.transaction {
    border: 1px solid rgb(184, 184, 184);
    padding: 1em;
    display: flex;
    flex-direction: column;
    justify-content: space-between
}

.top-row {
    display: flex;
    justify-content: space-between;
    margin-bottom: 1em;
}

.desc {
    color: rgb(98, 98, 98);
}


.transaction-amount {
    font-weight: 600;
}

.transaction-amount.Credit {
    color: green;
}

.transaction-amount.Debit {
    color: red;
}
</style>