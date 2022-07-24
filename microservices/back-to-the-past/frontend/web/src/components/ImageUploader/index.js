import React, { useState } from 'react';
import imageIcon from '../../assets/image-icon.SVG';
import './styles.scss';

const ImageUploader = ({
    onChange
}) => {
    const [image, setImage] = useState('');
    const [dropStateActivated, setDropStateActivated] = useState(false);

    const onDropImage = e => {
        e.preventDefault();

        // Get the first file available
        const file = e.dataTransfer.files[0];

        // Notify the parent component
        onChange(file);

        const fileReader = new FileReader();

        fileReader.onloadend = e => {
            const encodedImage = e.target.result;
            setImage(encodedImage);
            setDropStateActivated(false);
        }

        fileReader.readAsDataURL(file);
    }

    return (
        <div 
            className={`image-uploader-container ${dropStateActivated ? "drag" : ""}`} 
            onDragEnter={e => setDropStateActivated(true)}
            onDragLeave={e => setDropStateActivated(false)}
            onDragOver={e => {
                e.stopPropagation();
                e.preventDefault();
            }}
            onDrop={e => onDropImage(e)}
            >
                <div 
                    className={`image-viewer ${image ? "full-size" : ""}`} 
                    style={{
                        backgroundImage: `url(${image ? image : imageIcon})`
                    }}></div>
        </div>
    );
};

export default ImageUploader;