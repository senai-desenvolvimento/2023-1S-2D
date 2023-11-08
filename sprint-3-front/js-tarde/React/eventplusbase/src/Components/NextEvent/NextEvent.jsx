import React from 'react';
import './NextEvent.css';

const NextEvent = ( {title, description, eventDate, idEvento} ) => {
    
    function conectar(idEvento) {
        alert(`Conectando ao evento: ${idEvento}`)
    }

    return (
        <article className='event-card'>
            <h2 className='event-card__title'>{title}</h2>

            <p className='event-card__description'>{description}</p>
            <p className='event-card__description'>{eventDate}</p>

            <a  
                onClick={() => {conectar(idEvento)}}
                href="" className='event-card__connect-link'>Conectar</a>
        </article>
    );
};

export default NextEvent;