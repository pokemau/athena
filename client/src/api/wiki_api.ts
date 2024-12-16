const WIKI_API_URL = "https://localhost:7177/api/wikis";

async function createWiki(newWiki: object, API_URL: string) {
	try{
		const response = await fetch(`${API_URL}`, {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(newWiki),
		});

		if (response.ok){
			const data = await response.json();
			console.log("Wiki successfully created");
			return data;
		}else{
			const error = await response.json();
			console.log("Wiki creation error: " + error);
			return null;
		}
	} catch (error) {
		console.error(`getWikiByID ||||| ${error}`);
	}
}

async function getWikis() {}

async function getWikiByID(ID: string, API_URL: string) {
	try {
		const response = await fetch(`${API_URL}/${ID}`, {
			method: "GET",
		});

		const data = await response.json();
		if (data) {
			return data;
		}
		return null;
	} catch (error) {
		console.error(`getWikiByID ||||| ${error}`);
	}
}

async function editWiki(ID: string, newWiki: object, API_URL: string) {
	try{
		const response = await fetch(`${API_URL}/${ID}`, {
			method: "PUT",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(newWiki),
		});

		if (response.ok){
			const data = response; //not json cuz this returns boolean
			console.log("Wiki successfully edited");
			return data;
		}else{
			const error = response;
			console.log("Wiki edit error: " + error);
			return null;
		}
	} catch (error) {
		console.error(`editWiki ||||| ${error}`);
	}
}

async function deleteWiki(ID: string, API_URL: string) {
    try {
        const response = await fetch(`${API_URL}/${ID}`, {
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
            },
        });

        if (response.ok) {
            const data = response;  //not json cuz this returns boolean
            console.log("Wiki successfully deleted");
            return data; // You can return any useful information from the response
        } else {
            const error = response;
            console.log("Wiki delete error: " + error);
            return null; // Return null if there is an error
        }
    } catch (error) {
        console.error(`deleteWiki ||||| ${error}`);
        return null; // Return null if there's a fetch error
    }
}

export { WIKI_API_URL, createWiki, getWikiByID, editWiki, deleteWiki };
