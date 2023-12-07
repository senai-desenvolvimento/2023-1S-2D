import React from 'react';
import './VisionSection.css';

import Title from '../Title/Title';

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className="vision__box">
               <Title 
                titleText={"Visão"}
                color='white'
                additionalClass='vision__title'
               /> 

               <p className='vision__text'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Omnis error soluta ex, voluptate id atque, dicta ipsa magni sunt eveniet tenetur laborum aliquid eius? Tenetur saepe ex neque quod cum.
               Omnis eveniet laboriosam pariatur fugiat, ratione tempore iste in ullam sit modi, beatae libero, quod consequatur mollitia! Magnam, earum nesciunt nisi eius necessitatibus placeat optio eaque voluptatum voluptate labore impedit?</p>
            </div>
        </section>
    );
};

export default VisionSection;