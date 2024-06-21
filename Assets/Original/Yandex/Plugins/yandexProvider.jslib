mergeInto(LibraryManager.library, {

  Auth: function() {
    auth();
  },

  GetData: function() {
    getUserData();
  },

  SetData : function(data){
    setUserData(UTF8ToString(data));
  },

  ProjectStarted: function (){
    Start();
  }
  
});
