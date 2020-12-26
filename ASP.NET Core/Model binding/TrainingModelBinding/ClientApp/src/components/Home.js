import React, { Component } from 'react';
import axios from 'axios';
import qs from 'qs';

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
    
    callPostWithParametersFromQuery() {
        axios.post('sample/postWithParametersFromQuery?id=5')
            .then(res => console.info(res));
    }
    
    callPostWithParametersFromForm() {
        const name = 'val';
        const value = '1';
        axios.post('sample/PostWithParametersFromForm',
            qs.stringify({ name, value }),
            { headers: { 'content-type': 'application/x-www-form-urlencoded;charset=utf-8' }})
            .then(res => console.info(res));
    }
    
    callPostWithParametersFromBody() {
        axios.post('sample/PostWithParametersFromBody',
            JSON.stringify("body content"))
            .then(res => console.info(res));
    }
    
    callPostWithParametersFromHeader() {
        axios.post('sample/PostWithParametersFromHeader', null,
            { headers: { 'x-custom-header': 'val1' }})
            .then(res => console.info(res));
    }
    
    callPostWithFile() {
        const name = 'val';
        const value = '1';
        var file = new Blob([JSON.stringify({ name, value })], { type: 'application/json' });
        var formData = new FormData();
        formData.append("file", file, "file.json");    
        axios.post('sample/PostWithFile', formData,
            { headers: { 'content-type': 'multipart/form-data' }})
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
                      <button type="button" className="btn btn-link" onClick={this.callPostWithParametersFromQuery}>[FromQuery] parameters</button>
                      <button type="button" className="btn btn-link" onClick={this.callPostWithParametersFromForm}>[FromForm] parameters</button>
                      <button type="button" className="btn btn-link" onClick={this.callPostWithParametersFromBody}>[FromBody] parameters</button>
                      <button type="button" className="btn btn-link" onClick={this.callPostWithParametersFromHeader}>[FromHeader] parameters</button>
                      <button type="button" className="btn btn-link" onClick={this.callPostWithFile}>file parameter</button>
                  </div>
              </div>
          </div>
      );
    }
}
