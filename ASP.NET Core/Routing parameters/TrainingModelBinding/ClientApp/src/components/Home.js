import React, { Component } from 'react';
import axios from 'axios';

export class Home extends Component {
   static displayName = Home.name;
   
   callGetWithoutParameters() {
      axios.get('sample/getWithoutParameters')
           .then(res => console.info(res));
   }

   callGetWithParameters() {
      const id = 5;
      const value = 'val1';
      axios.get(`sample/getWithParameters/${id}?value=${value}`)
          .then(res => console.info(res));
   }

   callPostWithoutParameters() {
      axios.post('sample/postWithoutParameters')
          .then(res => console.info(res));
   }

   callPostWithParameters() {
      const name = 'val';
      const value = '1';

      axios.post('sample/postWithParameters', { name, value })
          .then(res => console.info(res));
   }

   render () {
     return (
         <div className="container">
             <div className="row">
                 <div className="col">
                     <h4>GET</h4>
                 </div>
             </div>
             <div className="row">
                 <div className="col">
                     <button type="button" className="btn btn-link" onClick={this.callGetWithoutParameters}>without parameters</button>
                     <button type="button" className="btn btn-link" onClick={this.callGetWithParameters}>with parameters</button>
                 </div>
             </div>
             <div className="row">
                 <div className="col">
                     <h4>POST</h4>
                 </div>
             </div>
             <div className="row">
                 <div className="col">
                     <button type="button" className="btn btn-link" onClick={this.callPostWithoutParameters}> without parameters</button>
                     <button type="button" className="btn btn-link" onClick={this.callPostWithParameters}>with parameters</button>
                     <button type="button" className="btn btn-link">[FromQuery] parameters</button>
                     <button type="button" className="btn btn-link">[FromForm] parameters</button>
                     <button type="button" className="btn btn-link">[FromBody] parameters</button>
                     <button type="button" className="btn btn-link">[FromHeader] parameters</button>
                     <button type="button" className="btn btn-link">file parameter</button>
                 </div>
             </div>
         </div>
     );
   }
}
