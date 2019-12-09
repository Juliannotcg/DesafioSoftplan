import React, { useEffect, useState } from 'react';
import { Button, Tab, Tabs, TextField, InputAdornment, Icon, Typography } from '@material-ui/core';
import { FuseAnimate, FusePageCarded, FuseChipSelect, FuseUtils } from '@fuse';
import { useForm } from '@fuse/hooks';
import API from 'app/API/Api';
import {useDispatch} from 'react-redux';
import * as Actions from 'app/store/actions';

import CalculoHeader from './CalculoHeader';
import ConfigApiDialog from './ConfigApiDialog';

function Calculo(props) {
    const dispatch = useDispatch();
    const [tabValue, setTabValue] = useState(0);
    const [resultado, setResultado] = useState(0);
    const [host, setHost] = useState("");
    const [link, setLink] = useState(null);
    const { form, handleChange, setForm } = useForm(null);

    useEffect(() => {

        if (sessionStorage.getItem("HostApi") != null)
        {
            setHost(sessionStorage.getItem("HostApi"));
            dispatch(
                Actions.showMessage({
                    message     : 'Caso queira trocar a porta, basta limpar a session do navegador.',
                    autoHideDuration: 6000,
                    anchorOrigin: {
                        vertical  : 'top-center',
                        horizontal: 'right'
                    },
                    variant: 'info'
                }))
        }
    
        setForm(('quantidade', 'valor'));
    }, []);


    function handleChangeTab(event, tabValue) {
        setTabValue(tabValue);
    }

    const CalcularRequest = (meses, valor) => {

        console.log("O QUE", host)
        API.CaulaJuros.get(`http://localhost:${host}/api/CalculaJuros?valorInicial=${valor}&meses=${meses}`)
        .then(response => setResultado(response.data));
    }

    const BuscarUrl = () => {
        API.CaulaJuros.get(`http://localhost:${host}/api/showMeTheCode`)
        .then(response => setLink(response.data));
    }

    const CalcularJurosEvent = () => CalcularRequest(form.Quantidade, form.Valor)

    return (
        <div>
        <ConfigApiDialog/>
        <FusePageCarded
            classes={{
                toolbar: "p-0",
                header: "min-h-72 h-72 sm:h-136 sm:min-h-136"
            }}
            header={
                <CalculoHeader/>
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
        </div>
    )
}

export default Calculo;
