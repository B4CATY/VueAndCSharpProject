import Main from '@/pages/Main'
import LinkPage from '@/pages/LinkPage'
import ParcedLinkPage from '@/pages/ParcedLinkPage'
import { createRouter, createWebHashHistory, createWebHistory } from 'vue-router'

const routes = [
    {
        path: '/',
        component: Main
    },
    {
        path: '/links',
        component: LinkPage
    },
    {
        path: '/links/:id',
        component: ParcedLinkPage
    },
]

const router = createRouter({
    routes,
    history: createWebHistory(process.env.BASE_URL)
});
export default router;