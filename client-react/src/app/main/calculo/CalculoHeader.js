import React from 'react';
import { Typography } from '@material-ui/core';
import { FuseAnimate, FusePageCarded, FuseChipSelect, FuseUtils } from '@fuse';

function CalculoHeader(props) {
    return (
        <div className="flex flex-1 w-full items-center justify-between">
            <FuseAnimate animation="transition.slideLeftIn" delay={300}>
                <Typography className="text-16 sm:text-20 truncate">
                    Calculador
                </Typography>
            </FuseAnimate>
        </div>
    )
}

export default CalculoHeader;
