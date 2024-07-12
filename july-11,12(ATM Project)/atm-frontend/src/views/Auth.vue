<template>
  <div class="auth-wrapper">
    <v-form @submit.prevent="handleSubmit" ref="form" class="auth-container" lazy-validation>
      <div class="inp-row">
        <label for="cardNo">Card No</label>
        <v-text-field v-model="cardNo" :rules="cardNoRules" la :counter="16" id="cardNo" variant="outlined" dense
          autocomplete="off"></v-text-field>
      </div>
      <div class="inp-row">
        <label for="pin">PIN Number</label>
        <v-text-field v-model="pin" :rules="pinRules" :counter="4" id="pin" variant="outlined" dense
          autocomplete="off"></v-text-field>
      </div>
      <div class="server-error-msg">
        {{ serverErrorMsg }}
      </div>
      <div class="inp-row btn-row">
        <v-btn type="submit" class="submit-btn" color="primary">Submit</v-btn>
      </div>
    </v-form>
  </div>
</template>

<script>
import axiosInstance from '@/axiosInterceptor';

export default {
  name: "Auth",
  data() {
    return {
      cardNo: "",
      pin: "",
      cardNoRules: [
        v => !!v || 'Card No is required',
        v => (v && v.length === 16) || 'Card No must be 16 characters'
      ],
      pinRules: [
        v => !!v || 'PIN Number is required',
        v => (v && v.length === 4) || 'PIN Number must be 4 characters'
      ],
      serverErrorMsg: ""
    };
  },
  methods: {
    async handleSubmit() {
      const { valid } = await this.$refs.form.validate()
      if (valid) {
        const obj = {
          cardNumber: this.cardNo,
          pin: this.pin
        }
        try {
          const result = await axiosInstance.post("/api/Atm/Login", obj)
          sessionStorage.setItem("token", result.data.token)
          sessionStorage.setItem("card", this.cardNo)
          this.$router.replace({name:"Options"})
        } catch (error) {
          alert(error.response?.data.message || "Internal Server Error")
        }
      }
    }
  }
}
</script>

<style scoped>
.auth-wrapper {
  display: grid;
  place-items: center;
  height: 100vh;
  height: 100svh;
}

.auth-container {
  width: min(25em, 90%);
  border: 1px solid rgb(159, 159, 159);
  padding: 2em;
  border-radius: .25em;
  display: flex;
  flex-direction: column;
  gap: .2em;
}

.inp-row {
  display: flex;
  flex-direction: column;
  gap: .5em;
}

label {
  color: rgb(73, 73, 73)
}

.btn-row {
  margin-top: .5em;
}

.submit-btn {
  width: fit-content
}

.server-error-msg {
  font-size: .875em;
  color: red;
  margin-top: .5em;
}
</style>