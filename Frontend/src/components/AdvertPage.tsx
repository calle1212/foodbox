import { useQueryClient } from '@tanstack/react-query';
import { Post } from '../types';
import { useMatch , Link} from '@tanstack/react-router';

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
                <ul>
            <li>Description: {Post?.description}</li>
            <li>Come over at: {Post?.date}</li>
            <li>Address: {Post?.location}</li>
            <li>Payment: {Post?.payment} kr</li>
            </ul>
            <button className='btn btn-primary'>Take Job</button>
            <div className='p-10'>
            <Link to="/profile" search={{id: Post?.creatorClerkId}} className='btn'>Check out creator</Link>
            </div>
        </div>
    )
}