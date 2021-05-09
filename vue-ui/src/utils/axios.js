import axios from 'axios';

export default axios.create({
    baseURL: 'https://localhost:44319/',
    timeout: 2000,
    headers: {
        'Content-Type': 'application/json'
    }
});