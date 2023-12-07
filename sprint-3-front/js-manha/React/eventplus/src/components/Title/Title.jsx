import React from 'react';
import './Title.css';

const Title = ( 
    {titleText, additionalClass = "" , color = ""} 
) => {
    return (
<h1 
    className={`title ${additionalClass}`} 
    style={ {color: color} }
>
    {titleText}
    <hr 
        className='title__underscore'
        style={{borderColor: color}} 
    />
</h1>
    );
};
export default Title;