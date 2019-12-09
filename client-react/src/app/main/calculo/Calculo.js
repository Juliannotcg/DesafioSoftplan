import React, { useState, useEffect } from 'react';
import { FusePageCarded } from '@fuse';
import CalculoHeader from './CalculoHeader';
import withReducer from 'app/store/withReducer';
import reducer from './store/reducers';
import CalculoRepositoriGit from './CalculoRepositoryGit';
import { API } from 'app/API/Api';

function Calculo(props) {

    const [urlGitProject, setUrlGitProject] = useState("");

    const buscarRepository = () => {
    //    API.get("/showMeTheCode").then(response => {
    //     setUrlGitProject(response.data)
    //    })
        setUrlGitProject("WWW.tESTE");
    };

    useEffect(() => {
        buscarRepository();
    }, []);

    return (
        <React.Fragment>
            <FusePageCarded
                header={
                    <CalculoHeader />
                }
                content={
                    <CalculoRepositoriGit urlGitProject={urlGitProject} />
                }
                innerScroll
            />
        </React.Fragment>
    );
}
export default withReducer('categoryApp', reducer)(Calculo);


