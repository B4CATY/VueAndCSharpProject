import { createApp } from 'vue'
import App from './App.vue'
import components from '@/components/UI'
import store from './components/store';
import router from './router/router';
import directives from './directives';
import { plugin, defaultConfig } from '@formkit/vue'
import '@formkit/themes/genesis'


const app = createApp(App);
components.forEach(component => {
    app.component(component.name, component)
});

directives.forEach(directive => {
    app.directive(directive.name, directive);
});

app.use(router)
    .use(plugin, defaultConfig)
    .use(store)
    .mount('#app')
