import React from 'react';
import {Redirect} from 'react-router-dom';
import {FuseUtils} from '@fuse';
import {CalculoConfig} from 'app/main/calculo/CalculoConfig';

const routeConfigs = [
    CalculoConfig
];

const routes = [
    ...FuseUtils.generateRoutesFromConfigs(routeConfigs),
    {
        path     : '/',
        component: () => <Redirect to="/calculo"/>
    }
];

export default routes;
