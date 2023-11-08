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
                    potatoClass='vision__title'
                />
                <p className='vision__text'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatibus autem assumenda, suscipit distinctio debitis nihil voluptates sunt sit, nesciunt dolorum dolorem magnam vitae illum commodi, magni quod eveniet ab dolor.Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptatibus autem assumenda, suscipit distinctio debitis nihil voluptates sunt sit, nesciunt dolorum dolorem magnam vitae illum commodi, magni quod eveniet ab dolor.</p>
            </div>
        </section>
    );
};

export default VisionSection;