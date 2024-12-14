const ARTICLE_API_URL = "https://localhost:7177/api/articles";

async function getArticles() {}

async function getArticleByID(ID: string, API_URL: string) {
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
		console.error(`getArticleByID ||||| ${error}`);
	}
}

export { ARTICLE_API_URL, getArticleByID };
