import React, { useState, useEffect } from 'react';
import './styles.scss';
import socket from '../../services/socketService';

const ImageProcess = () => {
    const [hub, setHub] = useState(null);
    const [processImageState, setProcessImageState] = useState('queued');
    const [sendEmailState, setSendEmailState] = useState('queued');
    const [processedImage, setProcessedImage] = useState();

    useEffect(() => {
        setHub(socket);
    }, []);

    useEffect(() => {
        if (hub) {
            hub.start()
                .then(_ => {
                    console.log('Connected!');

                    // TODO: Setup proper handlers
                })
                .catch(e => console.log('Connection failed: ', e));
        }
    }, [hub]);

    return (
        <div className="process-container">
            <h1>Current progress</h1>
            <div className="process">
                <div className={`process-icon ${processImageState}`}></div>
                <div className="process-text">Processing image</div>
            </div>
            <div className="process">
                <div className={`process-icon ${sendEmailState}`}></div>
                <div className="process-text">Sending email</div>
            </div>
            {
                processedImage
                ?
                    <button>Show image</button>
                :
                    <></>
            }
        </div>
    );
};

export default ImageProcess;