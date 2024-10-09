import { createRouter, createWebHistory } from 'vue-router';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      redirect: {
        name: 'sign-in'
      }
    },
    {
      path: '/sign-in',
      name: 'sign-in',
      component: () => import('@/module/auth/presentation/view/SignInView.vue')
    },
    {
      path: '/restaurant',
      name: 'restaurant-app',
      component: () => import('@/module/common/presentation/view/BaseView.vue'),
      redirect: {
        name: 'product'
      },
      children: [
        {
          path: 'accounts',
          name: 'accounts',
          component: () => import('@/module/auth/presentation/view/AccountView.vue')
        },
        {
          path: 'configuration',
          name: 'configuration',
          component: () => import('@/module/auth/presentation/view/ConfigurationView.vue')
        },
        {
          path: 'product',
          name: 'product',
          component: () => import('@/module/inventory/presentation/view/ProductView.vue')
        },
        {
          path: 'provider',
          name: 'provider',
          component: () => import('@/module/inventory/presentation/view/ProviderView.vue')
        },
        {
          path: 'food',
          name: 'food',
          component: () => import('@/module/food/presentation/view/FoodView.vue')
        },
        {
          path: 'report',
          name: 'report',
          component: () => import('@/module/report/presentation/view/ReportView.vue')
        }
      ]
    }
  ]
})

export default router
