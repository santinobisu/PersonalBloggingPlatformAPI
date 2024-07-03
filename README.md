# Using the API
_Note: You should use dotnet run --project PersonalBloggingPlatformAPI.Presentation to run the API_

## Endpoints
### » Post /Articles
JSON Structure:

{


  "Title": "" (Between 3 and 30 chars) (Required)

  
  "BodyText": "" (Between 30 and 1000 chars) (Required)

  
  "Tags": [] (Tags should be specified with their Id, which are Integers) (Optional)

  
}

Can return:
            
            Status 201 Created (CreatedAtAction) - If Successful
            
            Status 400 BadRequest - If request body wasn't valid


### » Get /Articles 
Returns a list of *All* the Articles existant on the DB. In case there aren't Articles it returns an empty List.

Can return: 

              Status 200 OK - Wether it's an empty list or not

### » Get /Articles/id
Returns the Article with the specified Id (Guid). In case it doesn't exist, it returns 404 NotFound

Can return: 
         
            Status 200 OK - If Successful

            Status 404 NotFound - If Article wasn't found


### » Get /Articles/byTags?tagNames=tag1&tagNames=tag2&tagNames=tag3...
Returns all the Articles which contain at least one of the specified Tags. In case there aren't Articles that satisfies this, it returns an empty List.

Can return: 
         
            Status 200 OK - Wether it's an empty list or not


### » Get /Articles/byPublishingDate?fromDate=YYYY-MM-DD&toDate=YYYY-MM-DD
Returns all the Articles whose Publishing Date value is between the specified Range. In case there aren't Articles that satisfies this, it returns an empty List.

Can return: 
         
            Status 200 OK - Wether it's an empty list or not

            
### » Update /Articles/id
Updates the targeted Article.
JSON structure should be the same as the POST endpoint:


{


  "Title": "" (Between 3 and 30 chars) (Required)

  
  "BodyText": "" (Between 30 and 1000 chars) (Required)

  
  "Tags": [] (Tags should be specified with their Id, which are Integers) (Optional)

  
}

Can return: 
         
            Status 200 OK - If Successful

            Status 404 NotFound - If Article wasn't found

            Status 400 BadRequest - If request body wasn't valid
            

### » Delete /Articles/id
Deletes the specified Article.

Can return: 
         
            Status 201 NoContent - Wether the Article existed or not
