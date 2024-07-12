<template>
    <div class="actions-container-buttons">
        <v-btn @click="$router.push('withdrawal')">Withdrawal</v-btn>
        <v-btn @click="$router.push('deposit')">Deposit</v-btn>
        <v-btn @click="$router.push('balance')">Check Balance</v-btn>
        <v-btn @click="$router.push('history')">History</v-btn>
    </div>
</template>

<script>

export default {
    name: "Options"
}


</script>


<style scoped>
.actions-container-buttons {
    padding: 10em 5em;
    background-color: #D9D9D9;
    display: flex;
    gap: 1em;
    flex-wrap: wrap;
}




</style>