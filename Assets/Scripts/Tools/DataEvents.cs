using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEvents<T> : EventArgs
{
    public T Data { get; set; }
    public T _Data { get; set; }
    public T _DataOne { get; set; }
    public T _DataTwo { get; set; }
    public T _DataThree { get; set; }

    public DataEvents(T data) => Data = data;
    public DataEvents(T data, T _data){ Data = data; _Data = _data; }  
    public DataEvents(T data, T _data , T _dataOne){ Data = data; _Data = _data; _DataOne = _dataOne;  }  
    public DataEvents(T data, T _data , T _dataOne , T _dataTwo)
    { 
        Data = data;
        _Data = _data;
        _DataOne = _dataOne; 
        _DataTwo = _dataTwo;
    }  
    public DataEvents(T data, T _data , T _dataOne , T _dataTwo , T _dataThree)
    {
        Data = data; 
        _Data = _data; 
        _DataOne = _dataOne;
        _DataTwo = _dataTwo;
        _DataThree = _dataThree;
    }  

}
