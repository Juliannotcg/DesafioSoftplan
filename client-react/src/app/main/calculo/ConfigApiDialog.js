import React, {useEffect, useCallback, useState} from 'react';
import {TextField, Button, Dialog, DialogActions, DialogContent, Icon, IconButton, Typography, Toolbar, AppBar, Avatar} from '@material-ui/core';
import { FuseAnimate } from '@fuse';
import {useForm} from '@fuse/hooks';
import {useDispatch} from 'react-redux';
import * as Actions from 'app/store/actions';

const defaultFormState = {
    host       : '',
};

function ConfigApiDialog(props)
{
    const dispatch = useDispatch();
    const {form, handleChange, setForm} = useForm(defaultFormState);
    const [open, setOpen] = useState(false);
  
    useEffect(() => {
        if (sessionStorage.getItem("HostApi") == null)
            setOpen(true);
    }, []);

   
    useEffect(() => {
        setForm(('host'));
    }, []);

    function salvarHostSession()
    {
        sessionStorage.setItem("HostApi", form.host);
        setOpen(false);

        dispatch(
            Actions.showMessage({
                message     : 'Show, salvo com sucesso.',
                autoHideDuration: 8000,
                anchorOrigin: {
                    vertical  : 'top-center',
                    horizontal: 'right'
                },
                variant: 'success'
            }))
    }

    return (
        <Dialog
            classes={{
                paper: "m-24"
            }}
            open={open}
            fullWidth
            maxWidth="xs"
        >

            <AppBar position="static" elevation={1}>
                <Toolbar className="flex w-full">
                    <Typography variant="subtitle1" color="inherit">
                        Configuração Host API
                    </Typography>
                </Toolbar>
                {/* <Typography className="text-16 sm:text-20 truncate">
                        Vamos lá, vou te ajudar.
                    </Typography>
                    <Typography className="text-10 sm:text-20 truncate">
                        Digite no campo a porta em que a API está rodando,
                        insira apenas os números, o restante é comigo.
                    </Typography> */}
      
            </AppBar>
            <form noValidate className="flex flex-col overflow-hidden">
                <DialogContent classes={{root: "p-24"}}>
                   <Typography className="text-10 sm:text-20 truncate">
                        Vamos lá, vou te ajudar.
                    </Typography>
                    <Typography className="text-8 sm:text-15 truncate">
                        Digite no campo a porta em que a API está rodando,
                    </Typography>
                    <Typography className="text-8 sm:text-15 truncate">
                        insira apenas os números, o restante é comigo.
                    </Typography>
                    <br/><br/>
                    <div className="flex">
                        <div className="min-w-48 pt-20">
                            <Icon color="action">alternate_email</Icon>
                        </div>
                        <TextField
                            className="mb-24"
                            label="Host API"
                            autoFocus
                            id="host"
                            name="host"
                            value={form.host}
                            onChange={handleChange}
                            variant="outlined"
                            type="number"
                            required
                            fullWidth
                        />
                    </div>
                </DialogContent>
                    <DialogActions className="justify-between pl-16">
                        <Button
                            variant="contained"
                            color="primary"
                            onClick={() => salvarHostSession()}
                            type="submit"
                        >
                            Confirmar
                        </Button>
                    </DialogActions>
            </form>
        </Dialog>
    );
}

export default ConfigApiDialog;