import axios from 'axios';

class API {
   
    static MotivosAfastamento = class {
        static get(resource) {
            return axios.get(process.env.REACT_APP_API_URL + resource);
        }
    }
}

export default API;