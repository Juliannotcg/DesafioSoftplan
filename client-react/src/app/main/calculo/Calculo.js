import React, { useEffect, useState } from 'react';
import { Button, Tab, Tabs, TextField, InputAdornment, Icon, Typography } from '@material-ui/core';
import { orange } from '@material-ui/core/colors';
import { makeStyles } from '@material-ui/styles';
import { FuseAnimate, FusePageCarded, FuseChipSelect, FuseUtils } from '@fuse';
import { useForm } from '@fuse/hooks';
import { Link } from 'react-router-dom';
import clsx from 'clsx';
import API from 'app/API/Api';

const useStyles = makeStyles(theme => ({
    productImageFeaturedStar: {
        position: 'absolute',
        top: 0,
        right: 0,
        color: orange[400],
        opacity: 0
    },
    productImageUpload: {
        transitionProperty: 'box-shadow',
        transitionDuration: theme.transitions.duration.short,
        transitionTimingFunction: theme.transitions.easing.easeInOut,
    },
    productImageItem: {
        transitionProperty: 'box-shadow',
        transitionDuration: theme.transitions.duration.short,
        transitionTimingFunction: theme.transitions.easing.easeInOut,
        '&:hover': {
            '& $productImageFeaturedStar': {
                opacity: .8
            }
        },
        '&.featured': {
            pointerEvents: 'none',
            boxShadow: theme.shadows[3],
            '& $productImageFeaturedStar': {
                opacity: 1
            },
            '&:hover $productImageFeaturedStar': {
                opacity: 1
            }
        }
    }
}));

function Calculo(props) {
    const [tabValue, setTabValue] = useState(0);
    const [resultado, setResultado] = useState(0);
    const [link, setLink] = useState(null);
    const { form, handleChange, setForm } = useForm(null);

    useEffect(() => {
        setForm(('quantidade', 'valor'));
    }, []);


    function handleChangeTab(event, tabValue) {
        setTabValue(tabValue);
    }

    const CalcularRequest = (meses, valor) => {
        API.CaulaJuros.get(`/CalculaJuros?valorInicial=${valor}&meses=${meses}`)
        .then(response => setResultado(response.data));
    }

    const BuscarUrl = () => {
        API.CaulaJuros.get('/showMeTheCode')
        .then(response => setLink(response.data));
    }

    const CalcularJurosEvent = () => CalcularRequest(form.Quantidade, form.Valor)

    return (
        <FusePageCarded
            classes={{
                toolbar: "p-0",
                header: "min-h-72 h-72 sm:h-136 sm:min-h-136"
            }}
            header={
                <div className="flex flex-1 w-full items-center justify-between">

                    <FuseAnimate animation="transition.slideLeftIn" delay={300}>
                        <Typography className="text-16 sm:text-20 truncate">
                            Calculador
                        </Typography>
                    </FuseAnimate>
                </div>
            }
            contentToolbar={
                <Tabs
                    value={tabValue}
                    onChange={handleChangeTab}
                    indicatorColor="secondary"
                    textColor="secondary"
                    variant="scrollable"
                    scrollButtons="auto"
                    classes={{ root: "w-full h-64" }}
                >
                    <Tab className="h-64 normal-case" label="Calculador" />
                    <Tab className="h-64 normal-case" label="Código fonte Git" />
                </Tabs>
            }
            content={
                form && (
                    <div className="p-16 sm:p-24 max-w-2xl">
                        {tabValue === 0 &&
                            (
                                <div>

                                    <TextField
                                        className="mt-8 mb-16"
                                        required
                                        label="Quantidade"
                                        name="Quantidade"
                                        id="quantidade"
                                        value={form.quantidade}
                                        onChange={handleChange}
                                        variant="outlined"
                                        type="number"
                                    />

                                    <TextField
                                        className="mt-8 mb-16"
                                        required
                                        type="number"
                                        label="Valor inicial"
                                        name="Valor"
                                        id="valor"
                                        value={form.valor}
                                        onChange={handleChange}
                                        autoFocus
                                        variant="outlined"
                                        fullWidth
                                    />

                                    <FuseAnimate animation="transition.slideLeftIn" delay={300}>
                                        <Typography className="text-16 sm:text-20 truncate">
                                            Resultado: {resultado}
                                        </Typography>
                                    </FuseAnimate>
                                    <br />
                                    <FuseAnimate animation="transition.slideRightIn" delay={300}>
                                        <Button
                                            className="whitespace-no-wrap"
                                            variant="contained"
                                            onClick={() => CalcularJurosEvent()}
                                        >
                                            Calcular
                            </Button>
                                    </FuseAnimate>
                                </div>

                            )}
                        {tabValue === 1 && (
                            <div>
                                <FuseAnimate animation="transition.slideRightIn" delay={300}>
                                    <Button
                                        className="whitespace-no-wrap"
                                        variant="contained"
                                        onClick={() => BuscarUrl()}
                                    >
                                        Buscar URL
                                    </Button>
                                </FuseAnimate>
                                <br /> <br />
                                <FuseAnimate animation="transition.slideLeftIn" delay={300}>
                                    <Typography className="text-16 sm:text-20 truncate">
                                        Link: {link}
                                </Typography>
                                </FuseAnimate>

                            </div>
                        )}
                    </div>
                )
            }
            innerScroll
        />
    )
}

export default Calculo;
