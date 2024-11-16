export type Article = {
	id: number;
	title: string;
	content: string;
};

export type Wiki = {
	title: string;
	description: string;
	articles: Article[];
};

const schoolArticles: Article[] = [
	{
		id: 1,
		title: "Importance of Education",
		content:
			"Education is the foundation for personal and societal growth, enabling individuals to reach their potential and contribute to their communities.",
	},
	{
		id: 2,
		title: "History of Schools",
		content:
			"Schools have evolved from ancient academies to modern institutions, adapting to societal needs and technological advancements.",
	},
	{
		id: 3,
		title: "Benefits of Extracurricular Activities",
		content:
			"Extracurricular activities like sports and arts help students develop teamwork, creativity, and leadership skills.",
	},
	{
		id: 4,
		title: "Challenges in Modern Education",
		content:
			"Modern education faces challenges such as access inequality, funding issues, and the integration of technology.",
	},
	{
		id: 5,
		title: "Future of Learning",
		content:
			"The future of learning includes personalized education, AI-powered tutors, and virtual classrooms to enhance the learning experience.",
	},
];
const gameArticles: Article[] = [
	{
		id: 1,
		title: "Mario",
		content: "Mario is a popular video game character created by Nintendo.",
	},
	{
		id: 2,
		title: "Zelda",
		content: "The Legend of Zelda is a classic action-adventure game series by Nintendo.",
	},
	{
		id: 3,
		title: "Donkey Kong",
		content: "Donkey Kong is an arcade game character created by Nintendo, known for his strength.",
	},
];
const wikis: Wiki[] = [
	{
		title: "Games",
		description: "Games are fun",
		articles: gameArticles,
	},
	{
		title: "School",
		description: "I love to go to school",
		articles: schoolArticles,
	},
];

export { wikis, gameArticles, schoolArticles };
