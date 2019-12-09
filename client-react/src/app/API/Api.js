import axios from 'axios';

class API {
   
    static CaulaJuros = class {
        static get(resource) {
            return axios.get(resource);
        }
    }
}

export default API;