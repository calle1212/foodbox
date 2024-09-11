import {
    useQuery,
} from '@tanstack/react-query'
import { Post } from '../types';
import AdvertCard from './AdvertCard';



export default function AdvertGallery(){

        //const sectionProps: sectionProps = { salties: data.salties }
        const { isPending, error, data, isFetching } = useQuery<Post[]>({
            queryKey: ["repoData"],
            queryFn: async () => {
                const response = await fetch(
                    'http://localhost:5063/api/Posts',
                )
                return await response.json()
            },
        })
    
        if (isPending) return 'Loading...';
        if (error) return 'An error has occurred: ' + error.message
        if (isFetching) return "is fetching...";
        //console.log(data);
        return (
            <div className='flex gap-4'>
                {data.map(post => <AdvertCard {...post}/> )}
            </div>
        )
}