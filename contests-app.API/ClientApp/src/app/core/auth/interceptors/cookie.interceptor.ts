import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';

import { API } from '../../tokens/api';

export const cookieInterceptor: HttpInterceptorFn = (req, next) => {
    return next(req.clone({ withCredentials: req.url.startsWith(inject(API)) }));
};
