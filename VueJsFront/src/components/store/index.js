import { createStore } from "vuex";
export default createStore({
    state: {
        isParcing: false,
    },
    getters: {
        getParcing(state) {
            return state.isParcing;
        }
    },
    mutations: {
        setParcingTrue(state) {
            state.isParcing = true;
        },
        setParcingFalse(state) {
            state.isParcing = false;
        }
    }
})