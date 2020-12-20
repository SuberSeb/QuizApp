using QuizApp.Backend.Library.Models;
using System;
using System.Collections.Generic;

namespace QuizApp.Backend.Library.Database
{
    public static class DatabaseInitializer
    {
        public static void SeedQuizData(DataContext dataContext)
        {
            dataContext.Quizzes.Add(GetQuizData());
            dataContext.SaveChanges();
        }

        private static Quiz GetQuizData()
        {
            return new Quiz()
            {
                Title = "Ваш стиль обучения и мышления, SOLAT (Торранс)",
                Description = "Объективно существуют разные стили обучения и мышления. " +
                              "В каждом вопросе описаны три разных стиля обучения и мышления. " +
                              "Выберите один, который лучше всего описывает ваши сильные стороны и предпочтения.",
                CreatedDate = DateTime.Now,
                Questions = GetQuestionsWithAnswers(),
            };
        }

        private static List<Question> GetQuestionsWithAnswers()
        {
            return new List<Question>()
            {
                new Question
                {
                    Title = "Вопрос 1 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Не очень хорошо запоминаю лица",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Не очень хорошо запоминаю имена",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 2 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Лучше всего усваиваю устные объяснения",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Лучше всего усваиваю объяснения в примерах",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 3 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Способен легко выражать чувства и эмоции",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Умеренно сдержан в выражении чувств и эмоций",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 4 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Весело и свободно эксперементирую в спорте, искусстве, все работы",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Систематичен и сдержан в экспериментаторстве",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 5 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю занятия, на которых дается один вид задания, после него другой и т.д.",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю занятия, на которых я работаю над несколькими заданиями одновременно",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 6 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю тесты, где нужно выбирать один правильный вариант из всего списка",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю эссе-тесты",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 7 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Хорошо интерпретирую язык телодвижений и интонационные аспекты устной речи",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Плохо интерпретирую язык телодвижений, завишу от того, что говорят люди",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 8 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Легко придумываю смешные фразы и поступки",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "С трудом придумываю смешные фразы и поступки",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 9 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю занятия, на которых я двигаюсь и что-нибудь делаю",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю занятия, на которых я слушаю других",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 10 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Использую фактическую, объективную информацию в суждениях",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Использую личный опыт и чувства в суждениях",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 11 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Легко, весело подхожу к решению проблемы",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Серьезно, по деловому подхожу к решению проблемы",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 12 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Умственно воспринимаю и реагирую на звуки и образы больше, чем на людей",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Существенно самопроизволен и творчески настроен в группе людей",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 13 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Почти всегда свободно использую любой доступный материал для работы",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Временами использую любой доступный материал для работы",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 14 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Люблю, когда мои занятия или работа запланированы, и я знаю, что конкретно я должен делать",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Люблю, когда мои занятия или работа не чужды гибкости и возможны перемены по мере продвижения",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 15 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Весьма изобретателен",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Времена изобретателен",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Никогда не изобретателен",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 16 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Лучше всего думаю лёжа на спине",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Лучше всего думаю сидя прямо",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 17 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Люблю занятия, на которых задания имеют четкую и непосредственную практическую применимость",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Люблю занятия, на которых задания не имеют четкой практической применимости",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 18 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Люблю догадываться и предсказывать многие ситуации, когда не уверен в каких-то вещах",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Скорее не стану догадываться, если не уверен",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 19 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Люблю выражать чувства и идеи простым языком",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Люблю выражать чувства и идеи стихами, песнями, танцами",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 20 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Обычно получаю много новых идей из поэзии, символов",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Временами получаю много новых идей из поэзии, символов",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 21 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю простые задачи",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю сложные задачи",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 22 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Реагирую на отзыв и эмоции",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Реагирую на призыв к логике",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 23 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю работать над проблемами последовательно, одна за другой",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю работать одновременно над несколькими проблемами",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 24 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю изучать традиционные области предмета",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю иметь дело с теорией и гипотезами нового предмета",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 25 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю аналитическое чтение, критику",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю творческое чтение",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 26 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю интуитивный подход к решению задач",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю логический подход к решению задач",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 27 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю зрительно представлять задачу при решении",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю проанализировать задачу вслух, чтобы решить ее",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 28 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю логически решать задачи",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю решать задачи, исходя из опыта, практики",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 29 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Умею хорошо объяснять устно",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Умею хорошо объяснять в движении и действии",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 30 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Учусь быстрее, когда преподаватель использует устные объяснения",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Учусь быстрее, когда преподаватель использует письменные объяснения",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 31 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Преимущественно полагаюсь на язык при запоминании и мышлении",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Преимущественно полагаюсь на образы при запоминании",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 32 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю анализировать уже завершенный материал",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю организовывать и доводить до конца незаконченный материал",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 33 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Люблю разговаривать и писать",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Люблю рисовать и манипулировать",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 34 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Легко могу потеряться даже в знакомой обстановке",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Легко ориентируюсь даже в незнакомой обстановке",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 35 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Более творческая натура, чем интеллектуальная",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Более интеллектуальная, чем творческая натура",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 36 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Люблю находиться в шумной людной обстановке, где что-нибудь все время происходит",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Люблю находиться в обстановке, где я могу сконцентрироваться на чем-то одном",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 37 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Преимущественно интересуюсь эстетическими проблемами: искусством, музыкой, танцами",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Преимущественно интересуюсь прикладными вещами: работой, походами, коллективными видами спорта",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 38 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Профессиональное призвание преимущественно к бизнесу, экономике",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Профессиональное призвание преимущественно к гуманитарным наукам",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 39 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Предпочитаю изучать детали и специфические факты",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "Предпочитаю общий обзор предмета, взгляд на картину в целом",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                },
                new Question
                {
                    Title = "Вопрос 40 из 40",
                    Description = "",
                    Answers = new List<Answer>
                    {
                        new Answer
                        {
                            Title = "Умственно восприимчив и реагирую на то, что слышу и читаю",
                            Score = 5
                        },
                        new Answer
                        {
                            Title = "В состоянии умственного поиска, самопознания в процессе учебы",
                            Score = 3
                        },
                        new Answer
                        {
                            Title = "Оба варианта",
                            Score = 1
                        }
                    }
                }
            };
        }
    }
}