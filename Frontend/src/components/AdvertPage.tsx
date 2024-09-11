import { useQueryClient } from '@tanstack/react-query';
import { Post } from '../types';
import { useMatch } from '@tanstack/react-router';

export default function AdvertPage(){
    const { search } = useMatch("/deal");
    const qid= search.id;
    console.log(qid);

    const queryClient = useQueryClient();

    const data : Post[] = queryClient.getQueryData(["repoData"])
    const Post = data.find(p => p.id == qid);

    console.log(data);
    console.log(Post);
    return (
        <div className='flex flex-col items-center'>
            <h1>{Post?.title}</h1>
            <figure className='max-w-96'>
                    <img
                        src={Post?.imageUrl || "https://images.pexels.com/photos/1860208/pexels-photo-1860208.jpeg?cs=srgb&dl=cooked-food-1860208.jpg&fm=jpg"}
                        alt="Food image" />
                </figure>
            <p>{Post?.description}</p>
            <p>{Post?.date}</p>
            <p>{Post?.location}</p>
            <p>{Post?.payment} kr</p>

            <button className='btn btn-primary'>Take Job</button>
        </div>
    )
}