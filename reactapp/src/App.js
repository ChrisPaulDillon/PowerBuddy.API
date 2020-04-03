import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import { store } from "../actions/store";
import { Provider } from "react-redux";
import DCandidates from '../components/DCandidates';
import layout from '../components/Layout/Layout';

class App extends Component {
  render() {
    return(
      <layout>This content is going to be rendered as the props.children inside the layout</layout>
    );
  }
}

export default App;
