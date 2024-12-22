module.exports = {
    '/api/**': {
        target: 'http://localhost:5000',
        secure: false,
        logLevel: 'debug',
        changeOrigin: true,
    },
};
