import { createRouter, createWebHistory } from 'vue-router'
import App from '@/App.vue'

const routes = [
  {
    path: '/',
    name: 'App',
    component: App,
    children: [
      {
        path: '',
        name: "Home",
        component: () => import("../views/HomeView.vue"),
        children: [
          {
            path: "",
            name: "Options",
            component: () => import("@/components/Options.vue")
          },
          {
            path: "/withdrawal",
            name: "Withdrawal",
            component: () => import("@/components/Withdrawal.vue")
          },
          {
            path: "/deposit",
            name: "Deposit",
            component: () => import("@/components/Deposit.vue")
          },
          {
            path: "/balance",
            name: "Balance",
            component: () => import("@/components/Balance.vue")
          }, {
            path: "/history",
            name: "History",
            component: () => import("@/components/History.vue")
          }
        ]
      },
    ]
  },
  {
    path: "/auth",
    name: "Auth",
    component: () => import("../views/Auth.vue")
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
