export type Article = {
	id: number;
	wikiID: number;
	wikiName: string;
	creatorID: number;
	articleTitle: string;
	articleContent: string;
};
export type ArticleUpdate = {
	articleTitle: string;
	articleContent: string;
};
