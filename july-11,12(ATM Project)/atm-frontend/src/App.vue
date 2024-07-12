<template>
  <router-view />
</template>

<script>

export default {
  name: 'App',
  data() {
    return {

    }
  },
  methods: {
    checkToken() {
      const token = sessionStorage.getItem("token")
      if (!token) {
        this.$router.replace({ name: "Auth" })
      }
    }
  },

  beforeMount() {
    this.checkToken()
  }
}
</script>
