import React from 'react';
import './ImageIlustrator.css';
import imageDefault from '../../assets/images/default-image.jpeg'

const ImageIllustrator = ({ alteText, imageRender = imageDefault, additionalClass = "" }) => {
    
    
    return (
        <figure className='illustrator-box'>
            <img 
                src={imageRender} 
                alt={alteText} 
                className={`illustrator-box__image ${additionalClass}`} 
            />
        </figure>
    );
};

export default ImageIllustrator;