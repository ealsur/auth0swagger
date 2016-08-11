using System;
using System.Collections.Generic;
using System.Linq;

//Simple In-memory repository
public class Repository
{
    private List<MyModel> _entries;
    public Repository(){
        _entries = new List<MyModel>(){
            new MyModel(){ Id=Guid.NewGuid().ToString(), Score=3, Name="John", Roles=new List<string>(){"Dev","Designer"} },
            new MyModel(){ Id=Guid.NewGuid().ToString(), Score=5, Name="Carla", Roles=new List<string>(){"Marketing"} }
        };
    }

    public IEnumerable<MyModel> Get(){
        return _entries;
    }

    public MyModel Add(MyModel newModel){
        newModel.Id =Guid.NewGuid().ToString();
        _entries.Add(newModel);
        return newModel;
    }

    public void Edit(string Id, MyModel newModel){
        var entry = _entries.FirstOrDefault(x=>x.Id == Id);
        if(entry==null){
            throw new KeyNotFoundException();
        }
        entry.Name = newModel.Name;
        entry.Score = newModel.Score;
        entry.Roles = newModel.Roles;
    }
    public void Delete(string Id){
        var entry = _entries.FirstOrDefault(x=>x.Id == Id);
        if(entry==null){
            throw new KeyNotFoundException();
        }
        _entries.Remove(entry);
    }
}