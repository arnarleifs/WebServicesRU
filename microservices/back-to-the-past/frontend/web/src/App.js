import React, { useState } from 'react';
import './styles/index.scss';
import ImageUploader from './components/ImageUploader';
import ImageProcess from './components/ImageProcess';
import { processImage } from './services/imageService';

const App = () => {
    const [isProcessingImage, setIsProcessingImage] = useState(true);
    const [file, setFile] = useState('');
    const [email, setEmail] = useState('');

    const submitImage = async () => {
        await processImage(email, file);
        setIsProcessingImage(true);
    }

    return (
        <div className="page">
            {
                isProcessingImage
                ?
                    <ImageProcess />
                :
                <>
                    <ImageUploader onChange={file => setFile(file)} />
                    <input 
                        type="text" 
                        value={email}
                        placeholder="Enter your email address..."
                        onChange={e => setEmail(e.target.value)} />
                    <button type="button" onClick={submitImage}>Process image</button>
                </>
            }
        </div>
    );
}

export default App;